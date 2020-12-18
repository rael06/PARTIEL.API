Salut Jérémy,

En bonus, j'ai ajouté mon input csv formatter, bon il est ce qu'il est faute de temps pour le rendre complètement autonome, mais il marche bien:

- Séparation de toutes les valeurs par ;
- La première ligne doit contenir le nom de l'entité à laquelle correspond le dto, et le nom de l'action du dto, exemple => artist;write ou artist;update (case insensitive)
- La seconde ligne doit contenir les valeurs à donner au dto correspondant séparées, exemple => nom de l'artiste;image de l'artiste (pour write) ou id;nom de l'artiste;image de l'artiste (pour update)

Il fonctionne de même pour les musiques.

