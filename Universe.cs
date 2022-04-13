using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Universe {

    double G = 6.6740184 * Math.Pow(10, -11);

    private int numberCelestialBodies;
    private int numberIterations;

    private int time;

    public Universe() {}

    /// <summary>
    /// Lê o arquivo de corpos celestes de inicialização do sistema de acordo com a quantidade máxima de corpos definida no arquivo
    /// </summary>
    /// <returns>Lista de corpos celeste</returns>
    public List<CelestialBody> ReadCelestialBodies() 
    {
        List<CelestialBody> celestialBodies = new List<CelestialBody>();
        string file = "inputBodies.txt";  

        // Verifica se o arquivo não existe, se não existir retorna uma quantidade vazia de corpos
        if (!File.Exists(file)) { 
            Console.WriteLine(String.Format("Arquivo {0} não existe", file)); 
            return celestialBodies;
        }  

        string[] lines = File.ReadAllLines(file);  
        int counter = 0;
        foreach (var line in lines)
        {   
            // Se for a primeira linha, pega as informações iniciais de execução
            if( counter == 0 ) {
                string[] data = line.Split(";");

                numberCelestialBodies = int.Parse(data[0]);
                numberIterations = int.Parse(data[1]);
                time = int.Parse(data[1]);
            }

            if( counter > 0 && counter <= numberCelestialBodies ) {
                CelestialBody newCelestialBody = new CelestialBody(line);
                celestialBodies.Add(newCelestialBody);
            }

            counter++;
        }

        return celestialBodies;
    }

    public void SaveCelestialBodies(List<string> output)
    {
        string file = "outputBodies.txt"; 

        FileStream myFile = new FileStream(file, FileMode.Open, FileAccess.Write);
        StreamWriter sw = new StreamWriter(myFile, Encoding.UTF8);


        foreach (var item in output)
        {
            sw.WriteLine(item);
        }

        sw.Close();
        myFile.Close();

    }

    public List<string> WriteIterationBodies(List<string> output, List<CelestialBody> bodies)
    {
        foreach(var body in bodies)
        {
            output.Add(body.formatOutputFile());
        }

        return output;
    }

    public double calculateEuclidienneDistance(CelestialBody body1, CelestialBody body2) 
    {
        return Math.Sqrt(Math.Pow((body1.getPosX() - body2.getPosX()), 2) + Math.Pow((body1.getPosY() - body2.getPosY()),2));
    }


    public void ApplyForceToBodies(List<CelestialBody> bodies) 
    {
        foreach(var body in bodies)
        {
            double Ax = body.getFx() / body.getMass();
            double Ay = body.getFy() / body.getMass();

            double Vx = body.getVelX() + (Ax * time);
            double Vy = body.getVelY() + (Ay * time);

            double Sx = body.getPosX() + (body.getVelX() * time) + ((Ax  / 2) * Math.Pow(time, 2));
            double Sy = body.getPosY() + (body.getVelY() * time) + ((Ay / 2) * Math.Pow(time, 2));
            
            body.setPosX(Sx);
            body.setPosY(Sy);
            body.setVelX(Vx);
            body.setVelY(Vy);
        } 
    }

    public void CleanForces(List<CelestialBody> bodies) 
    {
        foreach(var body in bodies)
        {
            body.setF(0.0f);
            body.setFx(0.0f);
            body.setFy(0.0f);
        } 
    }

    public void CalculateGravitationalForce(CelestialBody body1, CelestialBody body2) 
    {

        double r = calculateEuclidienneDistance(body1, body2);
        double F = (G * body1.getMass() * body2.getMass()) / Math.Pow(r, 2);

        double rx = (body1.getPosX() - body2.getPosX());
        double ry = (body1.getPosY() - body2.getPosY());


        // double Fx = F * Math.Cos( Math.Atan( (body1.getPosY() - body2.getPosY()) / ( body1.getPosX() - body2.getPosX()) ) );
        // double Fy = F * Math.Sin( Math.Atan( (body1.getPosY() - body2.getPosY()) / ( body1.getPosX() - body2.getPosX()) ) );


        double Fx =  F * (rx / r);
        double Fy = F * (ry / r);

        body1.setF(body1.getF() + F);
        body1.setFx(body1.getFx() + Fx);
        body1.setFy(body1.getFy() + Fy);

        body2.setF(body2.getF() + (F * (-1)));
        body2.setFx(body2.getFx() + (Fx * (-1)));
        body2.setFy(body2.getFy() + (Fy * (-1)));
    }
    

    public void run() 
    {
        List<CelestialBody> celestialBodies = ReadCelestialBodies();
        List<string> output = new List<string>();

        output.Add(String.Format("{0};{1}", celestialBodies.Count, numberIterations));

        if(celestialBodies.Count > 1) {
            for(int iteration = 0; iteration < numberIterations; iteration++) 
            {
                output.Add(String.Format("** Interacao {0} ************", iteration ));
                Console.WriteLine(String.Format("Iteração Nº {0}\n", iteration));
                
                for (var i = 0; i < celestialBodies.Count; ++i)
                {
                    for (var j = i + 1; j < celestialBodies.Count; ++j)
                    {                        
                        CalculateGravitationalForce(celestialBodies[i], celestialBodies[j]);
                    }
                    
                    Console.WriteLine(celestialBodies[i].formatOutputFile());
                    
                }

                ApplyForceToBodies(celestialBodies);
                output = WriteIterationBodies(output, celestialBodies);
                CleanForces(celestialBodies);

                Console.WriteLine("\n\n"); 
                
            }

            SaveCelestialBodies(output);
        }
    }

}