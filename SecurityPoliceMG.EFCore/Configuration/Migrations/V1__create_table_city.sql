create table tb_city
(
    id   uuid primary key default gen_random_uuid(),
    name varchar(200) not null,
    uf   varchar(2)   not null
);