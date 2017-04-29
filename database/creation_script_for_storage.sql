-- ������� ������������������ ��� ��������� ��������� ������

-- ��� ������� attribute_type
create sequence attribute_type_seq
increment by 1
start with 1
cache 2;

-- ��� ������� object_type
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

-- ������� ������� attribute_type, � ������� �������� ���������� �� ���������
create table attribute_type(
attribute_type_id int not null primary key,
attribute_name varchar2(15) not null,
attribute_type varchar2(15) not null,
object_type_id int not null,
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
