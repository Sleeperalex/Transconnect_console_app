# Probleme_C#_A3

## Modification 05-05-2024

##### Entreprise Model

**Classe entreprise**
* Ajout des méthodes suivantes :
	* AddClient()
	* RechercherClient()
	* RemoveClient()
	* ModifierClientDeLentreprise()
	* ModuleClient()
	* AfficherClient()

##### Personne Model

**Class Address**
* Ajout de la classe Addresse qui a comme attribut ville et code_postale pour trier par ville les clients

**Class Personne**
* Suppression du NSS pour le mettre que dans salarié 

**Classe Personne, Chauffeur, Client et salarié**
* Modification de postale par address de classe addresse

Class Client
* Création d'un attribut id pour les clients
* Ajout des méthodes
	* AddCommand()
	* PrixAchatCumuler()


##### Commande Model

**Classe commande** 
* Ajout du get PrixCommande
* Modification de l'idCommande pour que ce soit automatique
* Modification du type de l'attribut prixCommande en double car le prixUnitaire des produits est en double.
* Calcul du prix de la commande automatique 

**Classe Produit**
* Modification de l'idProduit pour que ce soit automatique
* Suppression de l'attribut quantité (on mettra le meme produit plusieurs fois pour la quantité)
* Ajout d'un get 



## Modification 05-05-2024 Alexandre
**Classe entreprise**
* J'ai juste modifier le nom de quelque de tes methodes 
	* AddClient() -> AjouterClient()
	* RemoveClient() -> SupprimerClient()
* Ajout de l'attribut organigrame pour faire les modifications de l'arbre
* Ajout du menu salarie

**Classe Salarie**
* methode ModifierSalarie()