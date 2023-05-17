package org.experimental.app.controller;

import org.experimental.app.connector.ProductRepository;
import org.experimental.app.entity.ProductEntity;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.logging.Logger;

@CrossOrigin(origins = "*")
@RestController
@RequestMapping("/api/product")
public class ProductController {
    private final Logger LOGGER = Logger.getLogger(ProductController.class.getName());

    private final ProductRepository productDb;

    @Autowired
    public ProductController(ProductRepository productDb) {
        this.productDb = productDb;
    }

    @GetMapping(path = "/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<ProductEntity> getProduct(@PathVariable Integer id) {
        LOGGER.info("Select objects with id=" + id + ".");
        return ResponseEntity.ok(productDb.findById(id).orElse(null));
    }

    @GetMapping(path = "/{idStart}-{idEnd}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<List<ProductEntity>> getProducts(@PathVariable Integer idStart, @PathVariable Integer idEnd) {
        LOGGER.info("Select objects in range: " + idStart + " <= id <= " + idEnd);
        return ResponseEntity.ok(productDb.findByIdRange(idStart, idEnd));
    }

    @PostMapping(path = "", produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<ProductEntity> insertProduct(@RequestBody ProductEntity model) {
        LOGGER.info("Insert object with id=" + model.getId() + ".");
        var createdEntity = productDb.save(model);
        return ResponseEntity.ok(createdEntity);
    }

    @PutMapping(path = "", produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<ProductEntity> updateProduct(@RequestBody ProductEntity model) {
        LOGGER.info("Update object with id=" + model.getId() + ".");
        var modifiedEntity = productDb.save(model);
        return ResponseEntity.ok(modifiedEntity);
    }

    @DeleteMapping(path = "/{id}")
    public ResponseEntity<?> deleteProduct(@PathVariable Integer id) {
        LOGGER.info("Delete object with id=" + id + ".");
        var entity = productDb.findById(id);
        if (entity.isEmpty()) {
            return new ResponseEntity<>("Object with id=" + id + "does not exist.", HttpStatus.NOT_FOUND);
        }
        productDb.delete(entity.get());
        return ResponseEntity.noContent().build();
    }
}
