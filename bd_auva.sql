create database bd_auva;

use bd_auva;

create table tb_departamento(
id int auto_increment primary key,
nome varchar(100)
);


create table tb_funcionario(
id int auto_increment primary key,
nome varchar(300),
valor_hora DECIMAL(6,2),
data_importacao datetime
);


create table tb_ponto_funcionario(
id int auto_increment primary key,
entrada timestamp,
saida timestamp,
almoco varchar(100),
data_ponto datetime ,
id_funcionario int ,
CONSTRAINT id_func_fk foreign key(id_funcionario)
References tb_funcionario(id)
);




