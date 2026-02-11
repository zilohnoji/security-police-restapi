CREATE TABLE tb_person
(
    id          UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name        VARCHAR(200)                    NOT NULL,
    birth_date  DATE                            NOT NULL,
    gender      VARCHAR(9)                      NOT NULL,
    mother_name VARCHAR(200),
    father_name VARCHAR(200),
    address_id  UUID REFERENCES tb_address (id) NOT NULL,
    user_id     UUID REFERENCES tb_user (id)    NOT NULL
);