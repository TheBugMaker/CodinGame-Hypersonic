using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
namespace codingame_hypersonic
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            int myId = int.Parse(inputs[2]);
            var target = new Position(6, 5); 
            Grid.setGrid(height, width);

            Me me = new Me() ;
            Enemy enemy = new Enemy() ; 

            // game loop
            while (true)
            {   
                // calculate the Impact ! 
                LinkedList<Impact> ims = new LinkedList<Impact>();
                LinkedList<Item> its = new LinkedList<Item>();
                LinkedList<Bomb> bombs = new LinkedList<Bomb>(); 
                #region setup 
                for (int i = 0; i < height; i++)
                {
                    string row = Console.ReadLine();
                    for (int j = 0; j < row.Length; j++)
                    {
                        Grid.g[j, i] = row[j]; 
                    }

                }
                int entities = int.Parse(Console.ReadLine());
                for (int i = 0; i < entities; i++)
                {
                    inputs = Console.ReadLine().Split(' ');
                    int entityType = int.Parse(inputs[0]);
                    int owner = int.Parse(inputs[1]);
                    int x = int.Parse(inputs[2]);
                    int y = int.Parse(inputs[3]);
                    int p1 = int.Parse(inputs[4]);
                    int p2 = int.Parse(inputs[5]);

                    if (entityType == 0)
                    {
                        //Player 
                        if (owner == myId)
                        {
                            me = new Me(x,y,p1) ;
                            Me.BombRange = p2;
                            Me.numberOfBombs = p1; 
                        }
                        else
                        {
                            enemy = new Enemy(x, y, p1); 
                        }
                    }else if(entityType == 2){
                        its.AddLast(new Item(new Position(x,y),p1)); 
                    }
                    else
                    {
                        ims.AddLast(new Impact(new Position(x,y)));
                        bombs.AddFirst(new Bomb(x, y, p1, p2)); 
                        //Bomb 
                        if (owner == myId)
                        {
                            me.bomb = new Bomb(p1); 
                        }
                        else
                        {   
                            enemy.bomb = new Bomb(p1); 
                        }

                    }
                }
                #endregion 
                // Set Gloabals  
                Grid.boms = bombs;
                do
                {
                    Safety.SetMapOfDestruction();
                    Console.Error.WriteLine("Calibrating"); 
                } while (!Safety.calibrateExplosionChaine());
                

                // apply memory to make the dude move  
                   
                 Grid.ApplyExplosions(ims);
                 Grid.ApplyItems(its);
                 Grid.ApplyBomPositions(bombs);

                

                 var path = Brain.navigateDirs(me);

                 Console.Error.WriteLine("Score : "+path.score); 
                 foreach(var im in path.road)
                 Console.Error.WriteLine( im.p +" hits "+im.hits+" is it Safe " + Safety.IsItSafeToStand(im.p));

          
                 var action = Commander.DoAction(path , me); 
                 Console.WriteLine(action);
            }
        }
    }
}