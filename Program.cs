using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace ufficio_postale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int contatoreChiusuraSpid = 0;
            bool ciclo = true;
            List<string> spedizione = new List<string>();
            List<string> finanza = new List<string>();
            List<string> spid = new List<string>();
            int sceltainiziale;
            while (ciclo)
            {
                Console.WriteLine("bevenuto operatore scegliuna funzione da fare :");
                Console.WriteLine("1) inserimento clienti");
                Console.WriteLine("2) servi clienti");
                Console.WriteLine("3) riceca cliente");
                Console.WriteLine("4) panoramica ufficio");
                Console.WriteLine(") chiudi ufficio");
                sceltainiziale = Convert.ToInt32(Console.ReadLine());
                //accettazione cliente
                if (sceltainiziale == 1)
                {
                    int eta = 0;
                    Console.WriteLine("hai scelto l' opzione INSERIMENTO CLIENTI");
                    Console.WriteLine("inserisci nome cliente");
                    string NomeCliente = Console.ReadLine();
                    Console.WriteLine("Scegli in che coda inserire il cliente");
                    Console.WriteLine("1) spedizione");
                    Console.WriteLine("2) finanza");
                    Console.WriteLine("3) spid");
                    int sceltaLista = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("inserisci l'eta dell utente");
                    Convert.ToInt32(Console.ReadLine());


                    if (sceltaLista == 1)
                    {
                        if (eta < 67)
                        {
                            spedizione.Add(NomeCliente);
                            Console.WriteLine("hai aggiunto correttamente l' utente " + NomeCliente + " alla coda spedizioni");
                        }
                        if (eta > 67)
                        {
                            spid.Insert((spid.Count - 1) / 2, NomeCliente);
                        }

                    }
                    else if (sceltaLista == 2)
                    {
                        if (eta < 67)
                        {
                            finanza.Add(NomeCliente);
                            Console.WriteLine("hai aggiunto correttamente l' utente" + NomeCliente + " alla coda finanza");
                        }
                        if (eta > 67)
                        {
                            spid.Insert((spid.Count - 1) / 2, NomeCliente);
                        }


                    }
                    else if (sceltaLista == 3)
                    {
                        if (eta < 67)
                        {
                            spid.Add(NomeCliente);
                            Console.WriteLine("hai aggiunto correttamente l' utente" + NomeCliente + " alla coda spid");
                        }
                        if (eta > 67)
                        {
                            spid.Insert((spid.Count - 1) / 2, NomeCliente);
                        }

                    }
                    else
                    {
                        Console.WriteLine("{ERRORE 67}hai fatto un errore sulla scelta della lista");
                    }




                }
                //servi il cliente
                if (sceltainiziale == 2)
                {
                    int sceltaservizo;
                    Console.WriteLine("hai scelto l'opzione servi cliente");
                    Console.WriteLine("Quale sportello?");
                    Console.WriteLine("1 - Spedizioni");
                    Console.WriteLine("2 - Finanza");
                    Console.WriteLine("3 - SPID");

                    int sceltaServizio = Convert.ToInt32(Console.ReadLine());

                    if (sceltaServizio == 1)
                    {
                        if (spedizione.Count > 0)
                        {
                            Console.WriteLine("Servito: " + spedizione[0]);
                            spedizione.RemoveAt(0);
                        }
                        else
                        {
                            Console.WriteLine("coda vuota");
                        }
                    }
                    else if (sceltaServizio == 2)
                    {
                        if (finanza.Count > 0)
                        {
                            Console.WriteLine("Servito: " + finanza[0]);
                            finanza.RemoveAt(0);
                        }
                        else
                        {
                            Console.WriteLine("coda vuota");
                        }
                    }
                    else if (sceltaServizio == 3)
                    {
                        if (spid.Count > 0)
                        {
                            Console.WriteLine("Servito: " + spid[0]);
                            spid.RemoveAt(0);
                            contatoreChiusuraSpid++;
                        }
                        else
                        {
                            Console.WriteLine("coda vuota");
                        }

                    }
                }
                // gestione errore biglietto
                if (sceltainiziale == 3)
                {
                    string nomeRicercato;
                    string sn; 

                    Console.WriteLine("Hai scelto l'opzione ricerca cliente");
                    Console.WriteLine("inserisci nome del cliente");
                    nomeRicercato = Console.ReadLine();
                    if (spedizione.Contains(nomeRicercato))
                    {
                        Console.WriteLine("il cliente si trova in nella fila spedizioni");
                        Console.WriteLine("il cliente vuole essere spostato?");
                        sn= Console.ReadLine();
                        if (sn == "si")
                        {
                            Console.WriteLine("in che fila vuole essere spostato?");
                            Console.WriteLine("1 - finanza");
                            Console.WriteLine("2 - spid");
                            int sceltaricercato = Convert.ToInt32(Console.ReadLine());
                            if (sceltaricercato == 1)
                            {
                                spedizione.Remove(nomeRicercato);
                                finanza.Add(nomeRicercato);
                                Console.WriteLine("nome aggiunto con successo a finanza");
                            }
                            if (sceltaricercato == 2)
                            {
                                spedizione.Remove(nomeRicercato);
                                spid.Add(nomeRicercato);
                                Console.WriteLine("nome aggiunto con successo a spid");
                            }

                        }

                    } 
                    else if (finanza.Contains(nomeRicercato))
                    {
                        Console.WriteLine("il cliente si trova in fila finanza");
                        Console.WriteLine("il cliente vuole essere spostato?");
                        sn= Console.ReadLine();
                        if (sn == "si")
                        {
                            Console.WriteLine("in che fila vuole essere spostato?");
                            Console.WriteLine("1 - Spedizioni");
                            Console.WriteLine("2 - spid");
                            int sceltaricercato = Convert.ToInt32(Console.ReadLine());
                            if (sceltaricercato == 1)
                            {
                                finanza.Remove(nomeRicercato);
                                spedizione.Add(nomeRicercato);
                                Console.WriteLine("nome aggiunto con successo a spedizione");
                            }
                            if(sceltaricercato == 2)
                            {
                                finanza.Remove(nomeRicercato);
                                spid.Add(nomeRicercato);
                                Console.WriteLine("nome aggiunto con successo a spid");
                            }

                        }
                    }
                    else if (spid.Contains(nomeRicercato))
                    {
                        Console.WriteLine("il cliente si trova nella fila spid");
                        Console.WriteLine("il cliente vuole essere spostato?");
                        sn = Console.ReadLine();
                        if (sn == "si")
                        {
                            Console.WriteLine("in che fila vuole essere spostato?");
                            Console.WriteLine("1 - Spedizioni");
                            Console.WriteLine("2 - Finanza");
                            int sceltaricercato = Convert.ToInt32(Console.ReadLine());
                            if (sceltaricercato == 1)
                            {
                             spid.Remove(nomeRicercato);
                             spedizione.Add(nomeRicercato);
                             Console.WriteLine("nome aggiunto con successo a spedizione");
                            }
                            if(sceltaricercato == 2)
                            {
                            spid.Remove(nomeRicercato);
                            finanza.Add(nomeRicercato);
                            Console.WriteLine("nome aggiunto con successo a finanza");
                            }

                        }
                    }
                    
                }
                //panoramica ufficio postale
                if (sceltainiziale == 4) 
                {
                    Console.WriteLine("hai scelto l'opzione panoramica ufficio");
                    Console.WriteLine("persone in fila spedizione" + spedizione.Count);
                    Console.WriteLine("persone in fila finanza" + finanza.Count);
                    Console.WriteLine("persone in fila SPID" + spid.Count);
                    Console.WriteLine("nomi persone in spedizione");
                    foreach (string s in spedizione) 
                    {
                     Console.WriteLine(s);
                    }
                    Console.WriteLine("nomi persone in finanza");
                    foreach(string f in finanza)
                    {
                     Console.WriteLine(f);
                    }
                    Console.WriteLine("nomi persone in spid");
                    foreach(string sp in spid)
                    {
                    Console.WriteLine(sp);
                    }


                }
                //chiusura ufficio spid
                if(contatoreChiusuraSpid == 3)
                {
                  for (int i = 0; i < spid.Count; i++) 
                    {
                    Console.WriteLine("l'ufficio spid sta chiudento");
                    if (spid.Count > 0)
                    {
                            finanza.Add(spid[i]);
                    }
                  }
                    spid.Clear();
                    
                }
                //CHIUSURA
                if (sceltainiziale == 5)
                {
                    for (int i = 0; i < spedizione.Count; i++) 
                    {
                        if (spedizione.Count > 0)
                        {
                            Console.WriteLine("Servito: " + spedizione[0]);
                            spedizione.RemoveAt(0);
                        }
                        else
                        {
                            Console.WriteLine("coda spedizioni vuota, effettuo chiusura");
                        }
                    }
                    
                    for(int j = 0;j < finanza.Count; j++) 
                    {
                        if (finanza.Count > 0)
                        {
                            Console.WriteLine("Servito: " + finanza[0]);
                            finanza.RemoveAt(0);
                        }
                        else
                        {
                            Console.WriteLine("coda finanza vuota, effettuo chiusura");
                        }
                    }
                 

                    for(int z = 0; z < spid.Count; z++)
                    {
                        if (spid.Count > 0)
                        {
                            Console.WriteLine("Servito: " + spid[0]);
                            spid.RemoveAt(0);
                        }
                        else
                        {
                            Console.WriteLine("coda spid vuota, effettuo chiusura");
                        }
                    }

                    if(spid.Count==0 && spedizione.Count==0 && finanza.Count == 0)
                    {
                        Console.WriteLine("UFFICIO CHIUSO, A DOMANI");
                    }
                }
            }
        }
    }
}


