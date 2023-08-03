
-- create
CREATE TABLE classmates (
  id INTEGER PRIMARY KEY,
  name TEXT NOT NULL,
  age TEXT NOT NULL,
  city TEXT NOT NULL
);

-- insert
INSERT INTO classmates VALUES (1, 'Valera', '31', 'Moscow');
INSERT INTO classmates VALUES (2, 'Petr', '25', 'Moscow');
INSERT INTO classmates VALUES (3, 'Anna', '27', 'Kazan');
INSERT INTO classmates VALUES (4, 'Sergey', '40', 'Novosibirsk');
INSERT INTO classmates VALUES (5, 'Dima', '18', 'Moscow');
INSERT INTO classmates VALUES (6, 'Roman', '32', 'Chelyabinsk');
INSERT INTO classmates VALUES (7, 'Petr', '23', 'Kaliningrad');
INSERT INTO classmates VALUES (8, 'Oksana', '45', 'Ryazan');

-- fetch 
SELECT name FROM classmates
WHERE city = 'Moscow' AND 18 <= age < 30