import json
with open(r"C:\Users\ruh010\AppData\LocalLow\ARamsay\ARamsay_test\Cauliflower, Brown Rice, and Vegetable Fried Rice\data.json", 'r') as fp:
    data = json.load(fp)
    igdInSteps = []
    for step in data['analyzedInstructions'][0]['steps']:
        sigd = ''
        for igd in step["ingredients"]:
            sigd += '|{};{}'.format(igd['name'], igd['image'])
        igdInSteps.append(sigd)
    
    with open(r"C:\Users\ruh010\AppData\LocalLow\ARamsay\ARamsay_test\Cauliflower, Brown Rice, and Vegetable Fried Rice\igdInSteps.txt", 'w') as fp:
        for igd in igdInSteps:
            fp.write('{}\n'.format(igd))
