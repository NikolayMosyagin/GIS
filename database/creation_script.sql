-- �������� ������� ��� �������� ��������� ������

--������� ������� info_schemes
create table info_schemes(
scheme_id int not null primary key,
scheme_name varchar(100)
);

-- ������� ������������������ ��� ��������� ��������� ����� ������� info_schemes
create sequence info_schemes_seq start with 1 increment by 1 cache 2;

-- ������� ������� ��� ������� info_schemes, ������� ��� ���������� ������� ���� �� ���������� ��������� ���� ���������� ���
create trigger info_schemes_trg
before insert on info_schemes
for each row
begin
    if :new.scheme_id is null then
        select info_schemes_seq.nextval into :new.scheme_id from dual;
    end if;
end;

commit;

-- ������� ������������������ ��� ��������� ��������� ����� ������� object_type;
create sequence object_type_seq
increment by 1
start with 1
cache 2;

-- ������� ������� object_type, � ������� �������� ���������� �� ��������
create table object_type(
object_type_id int not null primary key,
object_name varchar2(15) not null);

-- ������� ������� ��� ������� object_type. �� ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger object_type_trg
before insert on object_type
for each row
begin 
    if :new.object_type_id is null then
        select object_type_seq.nextval into :new.object_type_id from dual;
    end if;
end;

-- ������� ������� info_tables. ������ �������� ������, ������� ����� ������������ � �������.
create table info_tables(
table_id int not null primary key,
scheme_id int not null,
foreign key(table_id) references object_type(object_type_id),
foreign key(scheme_id) references info_schemes(scheme_id)
);

commit;

-- ������� ������������������ ��� ��������� ��������� ������ ������� object;
create sequence object_seq
increment by 1
start with 1
cache 2;

-- ������� ������� object, ��� �������� �������� ��������� ��� �������.
create table object(
object_id int not null primary key,
object_type_id int not null,
object_value int not null,
foreign key(object_type_id) references object_type(object_type_id));

-- ������� ������� ��� ������� object. �� ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger object_trg
before insert on object
for each row
begin 
    if :new.object_id is null then
        select object_seq.nextval into :new.object_id from dual;
    end if;
end;

-- ������� ������� info_objects ��� �������� �������� ������� ����� ������������ ��� �������.
create table info_objects(
object_id int not null primary key,
foreign key(object_id) references object(object_id)
);

commit;

-- ������� ������������������ ��� ��������� ��������� ������ ������� info_session;
create sequence info_session_seq start with 1 increment by 1 cache 2;

-- ������� ������� info_session ��� �������� ���������� �� ������ �������.
create table info_session(
session_id int not null primary key,
creation_date date not null);

-- ������� ������� ��� ������� object. �� ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger info_session_trg
before insert on info_session
for each row
begin
    if :new.session_id is null then
        select info_session_seq.nextval into :new.session_id from dual;
    end if;
end;

commit;

-- ������� ������������������ ��� ��������� ��������� ������ ������� attribute_type
create sequence attribute_type_seq
increment by 1
start with 1
cache 2;

-- ������� ������� attribute_type, � ������� �������� ���������� �� ��������� ������ ��������� ��� �������.
create table attribute_type(
attribute_type_id int not null primary key,
attribute_name varchar2(15) not null,
object_type_id int not null,
data_type varchar2(50),
foreign key(object_type_id) references object_type(object_type_id));

-- c������ ������� ��� ������� attribute_type. ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger attribute_type_trg
before insert on attribute_type
for each row
begin 
    if :new.attribute_type_id is null then
        select attribute_type_seq.nextval into :new.attribute_type_id from dual;
    end if;
end;

commit;


-- ������� ������������������ ��� ��������� ��������� ������ ������� info_cache;
create sequence info_cache_seq start with 1 increment by 1 cache 2;

-- ������� ������� info_cache, ��� �������� �������� ���������.
create table info_cache(
cache_id int not null primary key,
session_id int not null,
attribute_id int not null,
object_id int not null,
str_val varchar2(2000),
number_val number,
date_val date,
foreign key(session_id) references info_session(session_id),
foreign key(attribute_id) references attribute_type(attribute_type_id),
foreign key(object_id) references info_objects(object_id));

-- c������ ������� ��� ������� info_cache. ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger info_cache_trg
before insert on info_cache
for each row
begin
    if :new.cache_id is null then
        select info_cache_seq.nextval into :new.cache_id from dual;
    end if;
end;

commit;

-- ������� ������������������ ��� ��������� ��������� ������ ������� operation
create sequence operation_seq
increment by 1
start with 1
cache 2;

-- ������� ������� operation, ��� �������� ��������� ��������, �� ������� ����� �������� �������.
create table operation(
operation_id int not null primary key,
first_object_type_id int not null,
second_object_type_id int not null,
operation_name varchar2(15) not null,
operation_procedure varchar2(15) not null,
foreign key(first_object_type_id) references object_type(object_type_id),
foreign key(second_object_type_id) references object_type(object_type_id));

-- c������ ������� ��� ������� info_cache. ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger operation_trg
before insert on operation
for each row
begin 
    if :new.operation_id is null then
        select operation_seq.nextval into :new.operation_id from dual;
    end if;
end;

-- ������� ������������������ ��� ��������� ��������� ������ ������� rule
create sequence rule_seq
increment by 1
start with 1
cache 2;

-- ������� ������� Rule, ��� �������� ��������� ������.
create table rule(
rule_id int not null primary key,
rule_name varchar2(100) not null,
rule_description varchar2(2000) not null);

-- c������ ������� ��� ������� Rule. ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger rule_trg
before insert on rule
for each row
begin 
    if :new.rule_id is null then
        select rule_seq.nextval into :new.rule_id from dual;
    end if;
end;

-- ������� ������� ����� ����� operation � rule
create table rule_operation(
rule_id int not null,
operation_id int not null,
orderBy int not null,
foreign key(rule_id) references rule(rule_id),
foreign key(operation_id) references operation(operation_id));
commit;