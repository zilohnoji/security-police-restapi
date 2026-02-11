CREATE TABLE tb_person_scale
(
    id           UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    person_id    UUID REFERENCES tb_person (id) NOT NULL,
    scale_id     UUID REFERENCES tb_scale (id)  NOT NULL,
    hours_worked INT                            NOT NULL
);