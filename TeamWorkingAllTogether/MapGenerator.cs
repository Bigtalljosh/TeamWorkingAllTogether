using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TeamWorkingAllTogether
{
    class MapGenerator
    {
        Random rand = new Random();

        public List<List<bool>> GenerateMap(int size)
        {
            //create empty list
            List<List<bool>> grid = new List<List<bool>>();
            for (int x = 0; x < size / 2; x++)
            {
                grid.Add(new List<bool>());
                for (int y = 0; y < size / 2; y++)
                {
                    grid[x].Add(false);
                }
            }

            // random selection 
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid.Count; j++)
                {
                    if (rand.Next(100) < 70)
                    {
                        grid[i][j] = false;
                    }
                    else grid[i][j] = true;
                }
            }

            // remove cross section for pathway
            for (int x = 0; x < grid.Count; x++)
            {
                grid[grid.Count / 2][x] = false;
            }
            for (int y = 0; y < grid.Count; y++)
            {
                grid[y][grid.Count / 2] = false;
            }
           
            // reflect along x
            int height = grid.Count;
            for (int j = 0; j < height; j++)
            {
                grid.Add(grid[height - 1 - j]);
            }
           
            // add outside walls
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    if (i == 0 || i == grid.Count - 1 || j == 0 || j == grid[i].Count - 1)
                    {
                        grid[i][j] = true;
                    }
                }
            }
            return grid;
        }

        public List<Wall> generateWalls(List<Texture2D>textures,List<List<bool>> pos)
        {
            List<Wall> walls = new List<Wall>();
            for (int i = 0; i < pos.Count; i++)
            {
                for (int j = 0; j < pos[i].Count; j++)
                {
                    if (pos[i][j]) walls.Add(new Wall(textures[rand.Next(textures.Count)], i, j));
                }
            }
            return walls;
        }
    }
}
