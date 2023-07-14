using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject wall;



    [SerializeField] Sprite wall_spr;

    [SerializeField] Camera cam;

    private const int size = 250;
    private int[,] array_grid = new int[size, size];

    void Start()
    {
        /*
        for(int i = 0; i < array_grid.GetLength(1); i++)
        {
            array_grid[i, 0] = 1;
            if(i == array_grid.GetLength(1) - 1)
            {
                for(int j = 0; j < array_grid.GetLength(1); j++)
                {
                    if (j > (int)array_grid.GetLength(1) / 3 && j < (int)array_grid.GetLength(1) / 3 * 3)
                    {
                        array_grid[i, j] = 0;
                    }
                    else
                    {
                        array_grid[i, j] = 1;
                    }
                }
            }
        }
        for(int i = 0; i < array_grid.GetLength(1); i++)
        {
            array_grid[0, i] = 1;
            if (i == array_grid.GetLength(1) - 1)
            {
                for(int j = 0; j < array_grid.GetLength(1); j++)
                {
                    array_grid[j, i] = 1;

                }
            }
        }

        for(int i = array_grid.GetLength(1) - 1; i < array_grid.GetLength(0); i++)
        {
            array_grid[i, (int)array_grid.GetLength(1) / 3] = 1;
        }

        for (int i = array_grid.GetLength(1) - 1; i < array_grid.GetLength(0); i++)
        {
            array_grid[i, (int)array_grid.GetLength(1) / 3 * 3] = 1;
        } */
        for(int i = 0; i < 15; i++)
        {
            CreateBasicRoom(Random.Range(10, 20));
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (array_grid[i, j] == 1)
                {
                    //* wall_spr.rect.center.x
                    // * wall_spr.rect.center.y
                    Vector3 placement = new Vector3(i + cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, j + cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y);
                    Instantiate(wall, placement, transform.rotation);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void CreateBasicRoom(int block_size)
    {
        int center_point_x = Random.Range(0, size);
        int center_point_y = Random.Range(0, size);

        for (int i = 0; i < block_size; i++)
        {
            if ((center_point_x - i > 0 && center_point_x + i < size) && (center_point_y - i > 0 && center_point_y + i < size))
            {
                if (array_grid[center_point_x + i, center_point_y] == 1 || array_grid[center_point_x + i, center_point_y] == 2)
                {
                    CreateBasicRoom(block_size);
                    for(int j = 0; j < block_size; j++)
                    {
                        array_grid[center_point_x - (int)(block_size / 2) + j + 1, center_point_y - (int)block_size / 2 + j + 1] = 0;
                    }
                    return;
                }
                else if (array_grid[center_point_x - i, center_point_y] == 1 || array_grid[center_point_x - i, center_point_y] == 2)
                {
                    CreateBasicRoom(block_size);
                    for (int j = 0; j < block_size; j++)
                    {
                        array_grid[center_point_x - (int)(block_size / 2) + j + 1, center_point_y - (int)block_size / 2 + j + 1] = 0;
                    }
                    return;
                }
                else if (array_grid[center_point_x, center_point_y + i] == 1 || array_grid[center_point_x, center_point_y + i] == 2)
                {
                    CreateBasicRoom(block_size);
                    for (int j = 0; j < block_size; j++)
                    {
                        array_grid[center_point_x - (int)(block_size / 2) + j + 1, center_point_y - (int)block_size / 2 + j + 1] = 0;
                    }
                    return;
                }
                else if (array_grid[center_point_x, center_point_y - i] == 1 || array_grid[center_point_x, center_point_y - i] == 2)
                {
                    CreateBasicRoom(block_size);
                    for (int j = 0; j < block_size; j++)
                    {
                        array_grid[center_point_x - (int)(block_size / 2) + j + 1, center_point_y - (int)block_size / 2 + j + 1] = 0;
                    }
                    return;
                }


            } else
            {
                CreateBasicRoom(block_size);
                return;
            }

            
        }

        
        for(int j = 0; j < block_size; j++)
        {
            array_grid[center_point_x - (int)(block_size / 2) + j, center_point_y + (int)block_size / 2 - 1 ] = 1;
            array_grid[center_point_x - (int)(block_size / 2) + j, center_point_y - (int)block_size / 2] = 1;
            if(j == block_size - 1)
            {
                for(int k = 0; k < block_size; k++)
                {
                    array_grid[center_point_x - (int)block_size / 2 + j, center_point_y - (int)block_size / 2 + k] = 1;
                }
            }
            if(j == 0)
            {
                for (int k = 0; k < block_size; k++)
                {
                    array_grid[center_point_x - (int)block_size / 2 + j, center_point_y - (int)block_size / 2 + k] = 1;
                }
            }
            
        }
        
    }

    
}
