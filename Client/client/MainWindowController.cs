/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using fightagency;
using Thrift.Protocol;
using Thrift.Transport;

namespace flightagency
{
  public partial class MainWindowController {
    public interface ISync {
      void update(List<Flight> flights);
    }

    public interface Iface : ISync {
      #if SILVERLIGHT
      IAsyncResult Begin_update(AsyncCallback callback, object state, List<Flight> flights);
      void End_update(IAsyncResult asyncResult);
      #endif
    }

    public class Client : IDisposable, Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot)
      {
        iprot_ = iprot;
        oprot_ = oprot;
      }

      protected TProtocol iprot_;
      protected TProtocol oprot_;
      protected int seqid_;

      public TProtocol InputProtocol
      {
        get { return iprot_; }
      }
      public TProtocol OutputProtocol
      {
        get { return oprot_; }
      }


      #region " IDisposable Support "
      private bool _IsDisposed;

      // IDisposable
      public void Dispose()
      {
        Dispose(true);
      }
      

      protected virtual void Dispose(bool disposing)
      {
        if (!_IsDisposed)
        {
          if (disposing)
          {
            if (iprot_ != null)
            {
              ((IDisposable)iprot_).Dispose();
            }
            if (oprot_ != null)
            {
              ((IDisposable)oprot_).Dispose();
            }
          }
        }
        _IsDisposed = true;
      }
      #endregion


      
      #if SILVERLIGHT
      public IAsyncResult Begin_update(AsyncCallback callback, object state, List<Flight> flights)
      {
        return send_update(callback, state, flights);
      }

      public void End_update(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_update();
      }

      #endif

      public void update(List<Flight> flights)
      {
        #if !SILVERLIGHT
        send_update(flights);
        recv_update();

        #else
        var asyncResult = Begin_update(null, null, flights);
        End_update(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_update(AsyncCallback callback, object state, List<Flight> flights)
      #else
      public void send_update(List<Flight> flights)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("update", TMessageType.Call, seqid_));
        update_args args = new update_args();
        args.Flights = flights;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public void recv_update()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        update_result result = new update_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

    }
    public class Processor : TProcessor {
      public Processor(ISync iface)
      {
        iface_ = iface;
        processMap_["update"] = update_Process;
      }

      protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
      private ISync iface_;
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void update_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        update_args args = new update_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        update_result result = new update_result();
        try
        {
          iface_.update(args.Flights);
          oprot.WriteMessageBegin(new TMessage("update", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("update", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class update_args : TBase
    {
      private List<Flight> _flights;

      public List<Flight> Flights
      {
        get
        {
          return _flights;
        }
        set
        {
          __isset.flights = true;
          this._flights = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool flights;
      }

      public update_args() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              case 1:
                if (field.Type == TType.List) {
                  {
                    Flights = new List<Flight>();
                    TList _list16 = iprot.ReadListBegin();
                    for( int _i17 = 0; _i17 < _list16.Count; ++_i17)
                    {
                      Flight _elem18;
                      _elem18 = new Flight();
                      _elem18.Read(iprot);
                      Flights.Add(_elem18);
                    }
                    iprot.ReadListEnd();
                  }
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("update_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (Flights != null && __isset.flights) {
            field.Name = "flights";
            field.Type = TType.List;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            {
              oprot.WriteListBegin(new TList(TType.Struct, Flights.Count));
              foreach (Flight _iter19 in Flights)
              {
                _iter19.Write(oprot);
              }
              oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
          }
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("update_args(");
        bool __first = true;
        if (Flights != null && __isset.flights) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Flights: ");
          __sb.Append(Flights);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class update_result : TBase
    {

      public update_result() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("update_result");
          oprot.WriteStructBegin(struc);

          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("update_result(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }

  }
}