insert into owner(owner_name)
values('DOMODEDOVO_UAG');
commit;

insert into object_type(object_name, owner_id)
values('BUILDINGS', 1);
insert into object_type(object_name, owner_id)
values('STREETS', 1);
commit;

insert into cache_object(object_type_id, object_value)
values(1, 17501);
insert into cache_object(object_type_id, object_value)
values(1, 17567);
insert into cache_object(object_type_id, object_value)
values(2, 875);
insert into cache_object(object_type_id, object_value)
values(2, 881);
commit;

insert into attribute_type(attribute_name, object_type_id)
values('FLOORS', 1);
insert into attribute_type(attribute_name, object_type_id)
values('TOTAL_AREA', 1);
insert into attribute_type(attribute_name, object_type_id)
values('DATE_ACT', 2);
insert into attribute_type(attribute_name, object_type_id)
values('COMMENTS', 2);
commit;