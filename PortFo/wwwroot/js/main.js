

$.ajax({
    async: true,
	crossDomain: true,
	url: "https://famous-quotes4.p.rapidapi.com/random?category=all&count=2",
	method: "GET",
	"headers": {
		"X-RapidAPI-Key": "a5beed6c81msh4914332687175a4p15faf3jsn6773517229eb",
		"X-RapidAPI-Host": "famous-quotes4.p.rapidapi.com"
	}
	,

    success: function(data) {

        var words = document.getElementById('quote');




       data.map(function(quote){
        
        
       words.innerHTML += `
        <div key=${quote.id}>${quote.text}</div>
        
        
        `
    
        

       })
       
    }

    



}
)


