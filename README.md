Ce projet utilise le framework ASP.NET MVC avec Entity Framework (EF) pour la gestion des données, et AJAX (jQuery) pour une interaction utilisateur fluide, sans rechargement de page.
🔹 Fonctionnalités principales :

    Ajout, modification et suppression d'entités (ex : catégories, produits)

    Appels AJAX pour soumettre les formulaires ou effectuer des actions côté serveur de manière asynchrone

    Mise à jour dynamique des vues via des fragments HTML renvoyés depuis le serveur

    Entity Framework pour accéder à la base de données à travers des classes C#

🔹 Exemple de flux :

    L'utilisateur soumet un formulaire (ajout ou modification)

    Le formulaire est envoyé via AJAX (jQuery.ajax())

    Le contrôleur côté serveur traite la requête et retourne un fragment de vue mis à jour (partial view)

    La vue HTML est actualisée dynamiquement dans la page sans rechargement complet
