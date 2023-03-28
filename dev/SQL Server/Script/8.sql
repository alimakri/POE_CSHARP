select * from Personne inner join Ville on Personne.Ville = Ville.CodePostal
select * from Personne right join Ville on Personne.Ville = Ville.CodePostal
select * from Personne left join Ville on Personne.Ville = Ville.CodePostal
select * from Personne full outer join Ville on Personne.Ville = Ville.CodePostal

insert into Personne (Nom) values ('Jacques')