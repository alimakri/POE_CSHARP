use BD3
select * from Musicien

insert into Musicien (nom,age) values ('Bernard',24), ('Paul', 24), ('Jacques',58), ('Marie',36)

select * from Musicien

insert into Instrument (nom, type ,dateCreation) values ('Accordeon', 'Vent', GETDATE()), ('Accordeon','Vent', GETDATE()), ('Tambour','Percussion', GETDATE())

insert into Instrument (nom, type ,dateCreation) values ('Violon','Corde', '2023-18-02')

select * from Instrument

insert into Pret (Instrument, Musicien) values 
('5759209D-0461-4114-96F0-5B68066D588A','5ADE3E9D-8E12-4A43-8360-9F35FBED056E')

select * from Pret

select * from Pret,Musicien

select nom, EstRendu from Pret,Musicien where Pret.Musicien = Musicien.id

Select nom, EstRendu from Pret left outer join Musicien on Musicien.id = Pret.Musicien

insert into Pret (Instrument, Musicien) values 
('E6B0E46E-BE0E-49CA-902D-83A10A2639EE','5ADE3E9D-8E12-4A43-8360-9F35FBED056E'),
('5759209D-0461-4114-96F0-5B68066D588A','4CEF18E6-61C7-4AF3-876F-F6659B03FEA5'),
('E6B0E46E-BE0E-49CA-902D-83A10A2639EE','4CEF18E6-61C7-4AF3-876F-F6659B03FEA5'),
('D8AA47DC-EE56-4E82-A612-99143CCAC8FF','767EEA88-85DF-4E81-89BD-DB0B7B7DEFC3')

select * from pret

SELECT m.Nom MusicienNom, Instrument.Nom InstrumentNom, Instrument.iD EstRendu /*2*/
FROM Instrument /**1*/
full join Pret AS p on p.Instrument = Instrument.id
full join Musicien as m on p.Musicien = m.ID
where Instrument.Nom = 'Tambour' /*3*/
ORDER BY MusicienNom ASC /*4*/

SELECT * INTO Instrument2 from(
SELECT * from Instrument)t