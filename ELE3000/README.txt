cd C:\Users\Riadh\OneDrive\Documents\GitHub\ELE300-Projet\ELE3000

py -m venv venv

venv\Scripts\activate

python -m pip install --upgrade pip

pip3 install torch~=1.7.1 -f https://download.pytorch.org/whl/torch_stable.html

pip install mlagents

pip install importlib-metadata==4.4

mlagents-learn --help

mlagents-learn --run-id=test###