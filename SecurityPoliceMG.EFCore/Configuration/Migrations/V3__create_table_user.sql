CREATE TABLE tb_user
(
    id                        UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    email                     VARCHAR(100) unique NOT NULL,
    password                  VARCHAR(200)        NOT NULL,
    refresh_token             TEXT,
    refresh_token_expiry_time TIMESTAMP           NOT NULL
);