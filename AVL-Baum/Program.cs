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

            PrinterObject.StartPrinter(CommandsObject, BinaryTree);
        }
    }
}

//Eingabe beliebeige Zahlen hinzufügen      done
//Delegaten übergeben zum Sortieren         done
//Maximale Tiefe ausgeben                   done
//Elemente finden,                          done
// -"- hinzufügen                           done
// -"- entfernen                            done
//Abfragen, ob Element vorhanden ist        done

