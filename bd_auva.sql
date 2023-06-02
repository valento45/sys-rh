create database bd_auva;

use bd_auva;

create table tb_departamento(
id int auto_increment primary key,
nome varchar(100)
);

select id as Codigo, nome as NomeDepartamento from tb_departamento WHERE nome  LIKE '%'

select * from tb_departamento
