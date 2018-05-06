from life360 import life360
import requests

#Docs
#
# Modify the following with your information
#
# base_url 
# username
# password
#
# Down in the script there are patterns for names and device Ref ID's
# modify these to match your HS3 install

if __name__ == "__main__":
    def set_presence(device_number, presence):
        
        #Set the URL for your HS3 Install
        base_url = "<http://<YOUR_IP>"
        device_number = str (device_number)
        presence = str (presence)
        device_urn = "/JSON?request=controldevicebylabel&ref=" + device_number + "&label="

        url = base_url + device_urn + presence
        requests.get(url)
        
    # basic authorization hash (base64 if you want to decode it and see the sekrets)
    # this is a googleable or sniffable value. i imagine life360 changes this sometimes. 
    authorization_token = "cFJFcXVnYWJSZXRyZTRFc3RldGhlcnVmcmVQdW1hbUV4dWNyRUh1YzptM2ZydXBSZXRSZXN3ZXJFQ2hBUHJFOTZxYWtFZHI0Vg=="
    
    # your username and password (hope they are secure!)
    username = "<YOUR LIFE360 USERNAME>"
    password = "<YOUR LIFE360 PASSWORD>"

    #instantiate the API
    api = life360(authorization_token=authorization_token, username=username, password=password)
    if api.authenticate():

        #Grab some circles returns json
        circles =  api.get_circles()
        
        #grab id
        id = circles[0]['id']

        #Let's get your circle!
        circle = api.get_circle(id)

        #Let's display some goodies
        print("Circle name:", circle['name'])
        print("Members (" + circle['memberCount'] + "):")

        for m in circle['members']:
            print("\tName:", m['firstName'],m['lastName'])
            print("\tLocation:" , m['location']['name'])
            print("\tLongitude:", m['location']['longitude'])
            print("\tLatitude:", m['location']['latitude'])
            print("\tAddress:", m['location']['address1'])
            
            firstname = str (m['firstName'])
            place = str (m['location']['name'])
            
            #Note if the user signed up and used their Full Name in the sign in what is returned
            #will be their full name.  You must enter it here exactly as Life360 reports it
            #run from a terminal to verify the above output.

            if firstname == "<first_name>":
                device_num = "<ref_id>"
            elif firstname == "<first_name>":
                device_num = "<ref_id>"
            elif firstname == "<first_name>":
                device_num = "<ref_id>"
            
            #You can add/change locations based on what is setup in Life360 
            #I only use this for Home/Away purposes so I never extended it
            if place == "Home":
                presence = "on"
                set_presence(device_num, presence)
            elif place != "Home":
                presence = "off"
                set_presence(device_num, presence)
    else:
        print("Error authenticating")  
