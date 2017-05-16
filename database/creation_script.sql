-- �������� ������� ��� �������� ��������� ������

--������� ������� owner
create table owner(
owner_id int not null primary key,
owner_name varchar(100)
);

-- ������� ������������������ ��� ��������� ��������� ������ ������� owner
create sequence owner_seq start with 1 increment by 1 cache 2;

-- ������� ������� ��� ������� owner, ������� ��� ���������� ������� ���� �� ���������� ��������� ���� ���������� ���
create trigger owner_trg
before insert on owner
for each row
begin
    if :new.owner_id is null then
        select owner_seq.nextval into :new.owner_id from dual;
    end if;
end;

commit;

-- ������� ������������������ ��� ��������� ��������� ������ ������� object_type;
create sequence object_type_seq
increment by 1
start with 1
cache 2;

-- ������� ������� object_type, � ������� �������� ���������� �� ��������
create table object_type(
object_type_id int not null primary key,
owner_id int not null,
object_name varchar2(15) not null,
foreign key(owner_id) references owner(owner_id));

-- ������� ������� ��� ������� object_type. �� ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger object_type_trg
before insert on object_type
for each row
begin 
    if :new.object_type_id is null then
        select object_type_seq.nextval into :new.object_type_id from dual;
    end if;
end;

commit;

-- ������� ������������������ ��� ��������� ��������� ������ ������� cache_object;
create sequence cache_object_seq
increment by 1
start with 1
cache 2;

-- ������� ������� cache_object, ��� �������� �������� ��������� ��� �������.
create table cache_object(
object_id int not null primary key,
object_type_id int not null,
object_value int not null,
foreign key(object_type_id) references object_type(object_type_id));

-- ������� ������� ��� ������� cache_object. �� ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger cache_object_trg
before insert on cache_object
for each row
begin 
    if :new.object_id is null then
        select cache_object_seq.nextval into :new.object_id from dual;
    end if;
end;

-- ������� ������������������ ��� ��������� ��������� ������ ������� session;
create sequence cache_session_seq start with 1 increment by 1 cache 2;

-- ������� ������� session ��� �������� ���������� �� ������ �������.
create table cache_session(
session_id int not null primary key,
creation_date date not null,
session_description varchar2(1000));

-- ������� ������� ��� ������� session. �� ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger session_trg
before insert on cache_session
for each row
begin
    if :new.session_id is null then
        select cache_session_seq.nextval into :new.session_id from dual;
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


-- ������� ������������������ ��� ��������� ��������� ������ ������� cache_attribute;
create sequence cache_attribute_seq start with 1 increment by 1 cache 2;

-- ������� ������� cache_attribute, ��� �������� �������� ���������.
create table cache_attribute(
cache_id int not null primary key,
session_id int not null,
attribute_id int not null,
object_id int not null,
str_val varchar2(2000),
number_val number,
date_val date,
foreign key(session_id) references cache_session(session_id),
foreign key(attribute_id) references attribute_type(attribute_type_id),
foreign key(object_id) references cache_object(object_id));

-- c������ ������� ��� ������� cache_attribute. ���������� ��������� ���� �������, ���� ��� ���������� ������� �� �����������.
create trigger cache_attribute_trg
before insert on cache_attribute
for each row
begin
    if :new.cache_id is null then
        select cache_attribute_seq.nextval into :new.cache_id from dual;
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
Operation_description varchar2(2000),
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
foreign key(operation_id) references operation(operation_id) on delete cascade);
commit;