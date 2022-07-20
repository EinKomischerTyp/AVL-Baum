using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {

            CommandsClass CommandsObject = new CommandsClass();
            PrinterClass PrinterObject = new PrinterClass();
            AVL_Tree<int> BinaryTree = new AVL_Tree<int>(CommandsObject.Comp);


            PrinterObject.FillYourself(CommandsObject, BinaryTree);
            PrinterObject.PrintInt(BinaryTree);
            Console.ReadLine();







        }
    }

}

//Eingabe beliebeige Zahlen hinzufügen      done
//Delegaten übergeben zum Sortieren         not done (1/2 done)
//Maximale Tiefe ausgeben                   done
//Elemente finden,                          done
// -"- hinzufügen                           done
// -"- entfernen                            done
//Abfragen, ob Element vorhanden ist        not done
//

