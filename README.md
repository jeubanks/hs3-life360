# hs3-life360
Life360 script that integrates Home/Away with Homeseer 3

Requirements Pre-Setup Steps

- HS3
    - Create a virtual switch for each family member you want to track Home/Away status of
    - I just use first name but the device name and other information can be anything you choose
    - ** Recored the device ref id as it is needed later

- Windows
    - Python 3.6+
        - https://www.python.org/ftp/python/3.6.5/python-3.6.5.exe
        - When installing make sure to check the box "Add to PATH"
    - virtualenv
        - Open a CMD prompt
            - pip3 install virtualenv
            - pip3 install virtualenvwrapper-win
                - This is a very useful helper package for windows

    - Dated but good guide for installation if I'm not clear just add 3 to the commands as this was written for python 2
        - http://timmyreilly.azurewebsites.net/python-pip-virtualenv-installation-on-windows/

- Linux
    - Python 3.6+
    - Ubuntu/Debian
        - sudo apt-get install python3 python3-pip
        - sudo pip3 install virtualenv
    - Fedora
        - sudo dnf install python3 python3-pip
        - sudo pip3 install virtualenv

******** Script Changes: Do NOT Skip this part *********

    - This was developed for my own use and as such could be improved by using a list and dynamically creating the 
      devices and lots of cool HS3 stuff.  This was originally ported from a bash script, then to python from Home Assistant
      then I used it with Vera and now I'm using it with HS3.  Forgive the crudeness of the script until I learn more about
      HS3 and turn this into a proper plugin

    - Modify presence-checker.py
        - The script is commented but the important pieces are:
            - Username / Password for Life360
            - Family members and device ref Id's
            - Change the first name and ref id to match your HS3 setup.
            - add additional if statements for how ever many people are needed
                - Yes it can be improved and use a list.  I use a list for Vera but I haven't gotten that far with HS3 yet

    - Modify presence-checker.bat
        - Change the paths to match your install directory.  
            - I'll update this someday to use a generic path

Script Installation:

- Windows
    - Create virtual environment
        - Open CMD prompt
            - mkvirtualenv hs3-life360
            - Output
                C:\Users\johne>mkvirtualenv hs3-life360
                Using base prefix 'c:\\users\\johne\\appdata\\local\\programs\\python\\python36-32'
                New python executable in C:\Users\johne\Envs\hs3-life360\Scripts\python.exe
                Installing setuptools, pip, wheel...done.

                (hs3-life360) C:\Users\johne>

        - This will create a new folder/directory in your profile directory
            - Example:
            - C:\Users\johne\Envs\hs3-life360
        
        - The CMD prompt has changed to indicate you are now ACTIVE inside your new virtual environment
        
        - Install Life360 library Python Requirements
            - From the SAME CMD window
            - pip3 install requests

        - Copy the contents of the zip file into your virtual env.

    - Test things work
        - Still inside your virtual env (indicated by the CMD prompt) execute the following
            - python presence-checker.py
        
        - You should get output showing your Family Circle list and Members.
        - If things are setup correctly it will now turn on/off the virtual switch in HS3 indicating Home/Away status
    
- Linux
    - Create virtual environment
        - Userguide: https://virtualenv.pypa.io/en/stable/userguide/
        - Open a terminal
            - $ virtualenv <path>
            - $ source bin/activate
                - That activates the virtual env to install additional modules
            - $ deactivate
                - exits the virtual environment
    - Install python script
        - Copy the life360.py and presence-checker.py into your virtual env path
    - Install deps
        - Activate virtual env
            - pip3 install requests
            - test presence-checker.py (after modifying per notes above)

- Script Scheduling
    - To auto update the status within Homeseer you will need to schedule the script to execute periodically.  
    - Windows
        - Setup a task scheduler that calls the presence-checker.bat file.
        - Set the execute time to what suits your uses.  I adjusted mine to run ever 1 minute
    - Linux
        - A shell script should be used to activate the virtual environment then call presence-checker.py
        I haven't updated this piece yet, as I had not been using a virtual environment and was running this on a raspberry pi.
        
Notes:  I'll flesh out the Linux install later, it's actually a lot simpler than Windows but I'm doing this now as a
request for a Windows install/documentation.