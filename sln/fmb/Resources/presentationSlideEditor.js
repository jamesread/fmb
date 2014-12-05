window.slideEditorCount = 0;

String.prototype.endsWith = function(suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
};

function updateOriginalContent() {
        var presentation = $('#presentation');
        var slideEditors = $('textarea[id^="slideEditor"]').sort();

        presentation.val('');

        slideEditors.each(function(index, editor) {
				var slide = $(editor).val();
				 
				if (index > 0) {
					slide = "\n!SEP_SLIDE\n" + slide;
				}
				
                presentation.val(presentation.val() + slide);
        });

		console.log("updating");
}

function appendText(slideEditorNumber, textToAppend) {
	var textarea = $('textarea[id="slideEditor' + slideEditorNumber + '"]');

	if (!textarea.val().endsWith('\n')) {
		textarea.val((textarea.val() + "\n"));
	}  

	textarea.val(textarea.val() + textToAppend + "\n");
	updateOriginalContent();
}  

function loadInitialPresentation() { 
	$('#dynamicSlideArea').empty();
	window.slideEditorCount = 0;

	var slides = $('#presentation').val().trim().split('!SEP_SLIDE');

	$(slides).each(function(index, content) {
		newSlide(content);
	});
}

function deleteSlide(slideEditorNumber) { 
	$('div#slideEditorContainer' + slideEditorNumber).remove();
}

function newSlide(content) {
	var slideEditorNumber = ++window.slideEditorCount;
	var slideEditor = $('<textarea id = "slideEditor' + slideEditorNumber + '" rows = "10" cols = "80" />');
	slideEditor.blur(function() { updateOriginalContent() }); 
	slideEditor.attr('id', 'slideEditor' + slideEditorNumber);
	slideEditor.val(content.trim());
	slideEditorControls = $('<div class = "controls"><h3>Slide number ' + slideEditorNumber + '</h3></div>');

	slideEditorControls.append('Foreground:');  
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@foreground:red\')" style = "background-color: red" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@foreground:green\')" style = "background-color: green" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@foreground:blue\')" style = "background-color: blue" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@foreground:white\')" style = "background-color: white" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@foreground:black\')" style = "background-color: black" />');

	slideEditorControls.append('&nbsp;&nbsp;&nbsp;&nbsp;Background:');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@background:red\')" style = "background-color: red" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@background:green\')" style = "background-color: green" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@background:blue\')" style = "background-color: blue" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@background:white\')" style = "background-color: white" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@background:black\')" style = "background-color: black" />');

	slideEditorControls.append('&nbsp;&nbsp;&nbsp;&nbsp;Font Size:');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@fontSize:10\')" value = "10" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@fontSize:30\')" value = "30" />');
	slideEditorControls.append('<input type = "button" onclick = "appendText(' + slideEditorNumber + ', \'@fontSize:50\')" value = "50" />');  
	  
	slideEditorControls.append('&nbsp;&nbsp;&nbsp;&nbsp;Actions:');
	slideEditorControls.append('<span class = "fakeLink" onclick = "deleteSlide(' + slideEditorNumber + '); updateOriginalContent();">Delete slide</span>');
	 
	slideEditorContainer = $('<div id = "slideEditorContainer' + slideEditorNumber + '" />')
	slideEditorContainer.append(slideEditorControls);
	slideEditorContainer.append(slideEditor);
	$('#dynamicSlideArea').append(slideEditorContainer);
}