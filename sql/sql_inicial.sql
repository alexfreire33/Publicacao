INSERT INTO public.tb_cliente
("Id", "NmCliente", "NrCpf", "Email")
VALUES('69f7daf6-e443-4e90-8f8d-774f9fa7b028', 'mari', '03569846659', 'ma@gmail.com');


INSERT INTO public.tb_cliente
("Id", "NmCliente", "NrCpf", "Email")
VALUES('d5065db8-0047-48a2-b142-acec486631ef', 'jose', '03569865698', 'jos@gmail.com');


INSERT INTO public.tb_evento
("Id", "flAtivo", "vlEvento", "nmEvento", "dtEvento")
VALUES('d4065db7-0048-48a2-b142-acec486631ef'::uuid, true, 10, 'corrida teste', NULL);

INSERT INTO public.tb_evento
("Id", "flAtivo", "vlEvento", "nmEvento", "dtEvento")
VALUES('d4065db9-0048-48a2-b142-acec486631ef'::uuid, false, 20, 'corrida amador', NULL);