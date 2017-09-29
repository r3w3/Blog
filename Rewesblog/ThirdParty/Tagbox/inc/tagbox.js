/**
 * Blendet eine Tagbox ein in der Grafisch Tags angezeigt werden, welche über
 * doppelklick auf das tag gelöscht werden können
 * @author danny liebmann, MrKnowing
 * @param id: Tagboxname (aus html-Dokument)
 * @param varName: wie wurde die Instanz dieser Klasse benannt
 * @param entry_class: CSS-Klasse für einen Eintrag
 */
var Tagbox = function(id,varName, entry_class) {
	var boxname = id;
	var instanceName = varName;
	var entryclass = entry_class;
	var deleteMode = "onclick";
	var tmpDeleteMode = "onclick";
	var maxTagCharacters = 20;
	var editMode = true;
	/**
	 * Fügt ein Tag hinzu. Automatisches splitten wenn mit ","
	 * mehrere Tags übergeben wurden.
	 * @param tagname : tagname
	 */
	this.addTag = function(tagname){
		
		var sTag = tagname.split(",");
		for ( var int = 0; int < sTag.length; int++) {
			tagname = sTag[int].trim();
			//leere ausfiltern und zulange ausfiltern
			if (tagname == "" || tagname.length > maxTagCharacters) 
				{continue;} 
			if (!this.tagExist(tagname)){
				//tagdiv erstellen
				var entry = document.createElement("div");
				entry.setAttribute("id",boxname+"_tag_"+tagname);
				entry.setAttribute('class',entry_class);
				//entry.setAttribute('onclick',"this.remove();"+instanceName+".tagsToTextbox()");
				entry.setAttribute(deleteMode,"this.remove();"+instanceName+".tagsToTextbox()");
				
				
				//text setzen (in tagdiv)
				var content = document.createTextNode(tagname);
				entry.appendChild(content);
				
				//Umgebendes div holen
				var rootEntry = document.getElementById(boxname); 
				rootEntry.appendChild(entry);
			}
			//Namen in resultbox übernehmen
			this.tagsToTextbox();
		}
	}	
	/**
	 * Prüft ob ein Tag bereits existiert und in die
	 * Rahmenbox aufgenommen wurde.
	 * @param tagname: Tagname
	 * @returns boolean: true = ja, false = nein
	 */
	this.tagExist = function(tagname){
		var element = document.getElementsByTagName('div');
		for (var i = 0; i < element.length; i++){
			if (element[i].id == boxname+"_tag_"+tagname)
				{return true;}
		}
		return false;
	}
	
	/**
	 * Schreibt alle Tagnamen mit ", " getrennt in die Textbox.
	 */
	this.tagsToTextbox = function(){
		var element = document.getElementsByTagName('div');
		var result = document.getElementById(boxname+"_result");
		result.value="";
		var name = "";
		var namecount = (boxname+"_tag_").length;
		
		for (var i = 0; i < element.length; i++){
			name = element[i].id;
			if(name.substring(0, namecount) == boxname+"_tag_"){
				name = name.substring(namecount, name.length);
				
				if (result.value == "")
					result.value = name;
				else
					result.value = result.value +", "+ name;
			}
		}
	}
	
	/**
	 * Setzt das Event, auf das reagiert wird
	 * um ein Tag zu entfernen.
	 * @param index: 
	 * 		0: onclick
	 * 		1: ondblclick
	 * 		2: onmousedown
	 * 		3: onmouseup
	 * 		4: onmouseover
	 */
	this.setTagRemoveMode = function(index){
		switch (index) {
			case 0:
				deleteMode = "onclick";
				break;
			case 1:
				deleteMode = "ondblclick";
				break;
			case 2:
				deleteMode = "onmousedown";
				break;
			case 3:
				deleteMode = "onmouseup";
				break;
			case 4:
				deleteMode = "onmouseover";
				break;
			default:
				deleteMode = "onclick";
				break;
		}
		
		tmpDeleteMode = deleteMode;
	}
	
	/**
	 * Aktiviert oder deaktiviert den ReadModus.
	 * Bei aktivierten Lese-Modus ist das löschen
	 * von Tags nicht möglich.
	 * @param b: true = readmodus aktiv
	 */
	this.setReadMode = function(b){
		deleteMode = tmpDeleteMode;
		//event zum löschen wird deaktiviert,
		//bzw. umgelenkt
		if (b) {deleteMode = "data-nothing";}
	}
	
	/**
	 * Das event kann frei gewählt werden.
	 * @param eventname: name des events bpsw. "onclick"
	 */
	this.setTagRemoveEvent = function(eventname){
		deleteMode = eventname;
		tmpDeleteMode = deleteMode;
	}
	/**
	 * Legt fest wieviele Zeichen der Tagname 
	 * maximal haben darf.
	 * @param count: maximale Zeichen Anzahl
	 */
	this.setMaxTagChars = function(count){
		maxTagCharacters = count;
	}
};