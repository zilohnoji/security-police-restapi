CREATE TABLE tb_city
(
    id   UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(200) NOT NULL,
    uf   VARCHAR(2)   NOT NULL
);