package flightagency.repository;

import flightagency.domain.Entity;

public interface Repository<ID, E extends Entity<ID>> {

    E findOne(ID id);
    Iterable<E> findAll();
    E save(E entity);
}