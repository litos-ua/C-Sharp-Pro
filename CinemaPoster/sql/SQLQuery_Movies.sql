USE CinemaDb;

-- Фильмы
INSERT INTO Movies (Title, Description, Genre, DirectorId)
VALUES
('Inception', 'A mind-bending thriller', 7, 1),           -- SciFi
('Pulp Fiction', 'Crime and thriller masterpiece', 8, 2), -- Thriller
('Jurassic Park', 'Dinosaurs and action', 1, 3),          -- Action
('Titanic', 'Romance on the high seas', 6, 4),            -- Romance
('Barbie', 'Fantasy and comedy', 4, 5),                   -- Fantasy
('Get Out', 'Horror and social commentary', 5, 2),        -- Horror
('The Dark Knight', 'Batman battles the Joker', 8, 1),    -- Thriller
('La La Land', 'Romance and music', 6, 5),                -- Romance
('The Shining', 'Classic horror masterpiece', 5, 4),      -- Horror
('Dunkirk', 'WWII historical drama', 3, 1),               -- Drama
('Blade Runner 2049', 'SciFi and mystery', 7, 3),         -- SciFi
('Seven', 'Crime and thriller', 8, 2);                    -- Thriller
