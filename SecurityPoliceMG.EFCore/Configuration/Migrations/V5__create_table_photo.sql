CREATE TABLE tb_photo
(
    id         UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    created_at TIMESTAMP                      NOT NULL,
    bucket     VARCHAR(50)                    NOT NULL,
    hash       VARCHAR(100)                   NOT NULL,
    person_id  UUID REFERENCES tb_person (id) NOT NULL
);