CREATE TABLE smoothies (
  id int NOT NULL AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  price DECIMAL(10,2) NOT NULL,
  PRIMARY KEY(id)
);

-- INSERT INTO smoothie (name, description, price)
-- VALUES ("Plain", "bun", 10.99);

-- SELECT * FROM burgers;

-- ALTER TABLE smoothie MODIFY COLUMN price DECIMAL(10,2);

-- UPDATE burgers SET price = 7.99 WHERE id = 1;

-- UPDATE burgers SET 
-- price = 7.99, 
-- name = "The Plane Bane", 
-- description = "batmans enemy" 
-- WHERE id = 2;

-- DELETE FROM burgers WHERE id = 1;

-- DROP TABLE Smoothie;