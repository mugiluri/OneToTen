# OneToTen
Remote Icebreaker game. How fast and correct can you answer 15 questions? 
They're simple random math questions involving numbers 1-10. 
The code is programmed in C# with #microsoft #visualstudio 2019. 
It's a windows desktop application. #winforms Anyone can do it. 
Ideal for remote teams and hackathon warm up.

#### Algorithm ####
- The programmable code is in [this file](Form1.cs)

#### Calculating the score ####
- Based on;
  - t = Time in seconds
  - Ca = Number of correct answers
  - C = Constant(180)
  - Sc = Ca*(C/t)
    - The more correct answers one gets, the higher the score
    - The more time one uses, the lower the constant hence score
  
Score = NoOfCorrectAnswers*(180/time)

Clone/zip the project and open it with visual studio.
[Find Windows setup file here](https://drive.google.com/drive/folders/1rmFn20IXY4f9pz_pt4YHJYTXuJnlaWhG?usp=sharing)
