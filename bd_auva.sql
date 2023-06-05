create database bd_auva;

use bd_auva;

create table tb_departamento(
id int auto_increment primary key,
nome varchar(100)
);

drop table tb_funcionario
create table tb_funcionario(
id int auto_increment primary key,
nome varchar(300),
valor_hora DECIMAL(6,2),
data_importacao datetime
);

drop table tb_ponto_funcionario
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

select id as Codigo, nome as Nome, valor_hora as ValorHora, data_importacao as DataImportacao from tb_funcionario WHERE id = 1

select * from tb_funcionario

insert into tb_funcionario (nome, valor_hora, data_importacao) values (nome,valor_hora, data_importacao)


