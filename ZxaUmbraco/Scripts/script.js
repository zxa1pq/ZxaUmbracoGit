

$(function () {
        
    $('#adresse').dawaautocomplete({
        select: function (event, data) {

            console.log(data.tekst)
            //   $('#adresse-choice').text(data.tekst);
          //  console.log("@addresse-choice")

            console.log(data.data.vejnavn);
            //Make sure the response is not Empty or undefined
            if (data.data != null && data.data.vejnavn !== 'undefined') {

                console.log('inside first if');
                //Make the Address string e.g. [Streetname] [No.] 
                var addressStr = data.data.vejnavn + " " + data.data.husnr;

                //If address has multiple floors, add it to the Address string, [Floor] += [Streetname] [No.] 
                if ('etage' in data.data && data.data.etage != null && data.data.etage !== 'undefined') {

                    addressStr += ", " + data.data.etage;
                }
                else {
                    console.log("etage Not defined!");
                }
                //If address has multiple doors, add it to the Address string, [Door] += [Streetname] [No.] [Door]
                if ('dør' in data.data && data.data.dør != null && data.data.dør !== 'undefined') {
                    addressStr += ", " + data.data.dør;
                }
                else {
                    console.log("dør undefined");
                }
                //Fill out inputFields
                $('#adresse').val(addressStr);
                $('#senderPostal').val(data.data.postnr);
                $('#senderCity').val(data.data.postnrnavn);

            }
            $('#adresse').trigger('blur');
        },

    }).on('blur', function () {

        console.log("BLURRED?")
        return false;

        // dont actually do all this when we blur the field!!
        //this == inputfeltet
        //  console.log(currentResponse);
        // clean up address field contents

        

     
    });
    });
