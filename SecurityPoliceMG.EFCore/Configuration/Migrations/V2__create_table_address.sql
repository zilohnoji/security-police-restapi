CREATE TABLE tb_address
(
    id           UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    street_type  VARCHAR(50)                  NOT NULL,
    street       VARCHAR(200)                 NOT NULL,
    number       INT                          NOT NULL,
    neighborhood VARCHAR(100)                 NOT NULL,
    city_id      UUID REFERENCES tb_city (id) NOT NULL
);