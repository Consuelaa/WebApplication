select * from Activities

select  Id,
        Elemente,
        Pret_Element,
        (Elemente * Pret_Element) as Pret_Manopera from Activities;

 select  Id,
         Pret_manopera,
         Adaos,
        (Pret_manopera + Adaos) as Pret_Final from Activities;
        
        



