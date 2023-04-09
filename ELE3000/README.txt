cd C:\Users\Riadh\OneDrive\Documents\GitHub\ELE300-Projet\ELE3000

py -m venv venv

venv\Scripts\activate

python -m pip install --upgrade pip

pip3 install torch~=1.7.1 -f https://download.pytorch.org/whl/torch_stable.html

pip install mlagents

pip install importlib-metadata==4.4

mlagents-learn --help

mlagents-learn config\ppo\GetPortal.yaml --run-id=test###

tensorboard --logdir=results --host localhost



// MAC

cd /Users/kamelbenseghier/Documents/GitHub/ELE300-Projet/ELE3000

python -m venv venv

source venv/bin/activate

python3 -m pip install --upgrade pip

pip3 install torch~=1.9.1 -f https://download.pytorch.org/whl/torch_stable.html   

pip install mlagents

pip install protobuf==3.20.0

mlagents-learn --help

mlagents-learn config/ppo/GetPortal.yaml --run-id=test###


// RAPPORT

UNE ERREUR NOTÉE 

POURQUOI CETTE SOLUTION

ÉTAT DES CHOSES 

GRILLE D'AUTO EVALUATION A AJOUTER