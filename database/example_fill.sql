insert into info_schemes(scheme_name)
values('DOMODEDOVO_UAG');
commit;

insert into info_tables(table_name, scheme_id)
values('BUILDINGS', 1);
commit;

insert into info_objects(table_id, table_object_id)
values(1, 17501);
insert into info_objects(table_id, table_object_id)
values(1, 17567);
commit;

insert into info_attributes(attribute_name, table_id)
values('floors', 1);
insert into info_attributes(attribute_name, table_id)
values('total_area', 1);
insert into info_attributes(attribute_name, table_id)
values('build_name', 1);
commit;

