CREATE TABLE tb_scale
(
    id           UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    is_completed BOOL      NOT NULL,
    created_at   TIMESTAMP NOT NULL,
    starts_at    TIMESTAMP NOT NULL,
    finished_at  TIMESTAMP NOT NULL,
    description  TEXT      NOT NULL
);