Tu dois utiliser le WCF Service et la BLLBDVID comme c'est fait pour intialiser les deux dataGridView

La nouvelle méthode s'appelle SelectSomeMovies(int number,int skip);
Number = nombre de films que tu veux
Skip = Grosso modo la page car ca va passer Skip*number film.

Exemple
SelectSomeMovie(50,0) => 50 premiers films
SelectSomeMovie(50,2) => 100-150 parmi les films

essaie de cacher les colonnes inutiles.