create database bd_auva;

use bd_auva;

create table tb_departamento(
id int auto_increment primary key,
nome varchar(100)
);

drop table tb_funcionario
create table tb_funcionario(
id int auto_increment primary key,
id_departamento int,
nome varchar(300),
valor_hora decimal,
data_importacao datetime,
CONSTRAINT id_departamento_fk foreign key(id_departamento)
References tb_departamento(id)
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

select tp.id as Codigo , entrada as Entrada, saida as Saida, almoco as Almoco, 
data_ponto as DataPonto, id_funcionario as IdFuncionario from tb_ponto_funcionario as tp inner join tb_funcionario as tf on tf.id = tp.id_funcionario
where tf.id = 1


