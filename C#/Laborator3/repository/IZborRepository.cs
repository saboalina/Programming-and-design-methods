﻿using Laborator3.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator3.repository
{
    interface IZborRepository : IRepository<int, Zbor>
    {
        Zbor Update(Zbor entity);
    }
}
