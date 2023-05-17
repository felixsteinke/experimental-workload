package org.experimental.app.connector;

import org.experimental.app.entity.ProductEntity;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ProductRepository extends CrudRepository<ProductEntity, Integer> {
    @Query("select e from Product e where :idStart <= e.id and e.id <= :idEnd")
    List<ProductEntity> findByIdRange(@Param("idStart") Integer idStart, @Param("idEnd") Integer idEnd);
}
