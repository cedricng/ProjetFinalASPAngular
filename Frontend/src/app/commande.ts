export class Commande {
    id:number | undefined;
    idClient:number | undefined;
    date:number | undefined;
    prixTotal: number | undefined;
    infos: Map<number,number> =new Map<number,number>();
    
}
