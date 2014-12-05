<div>
	<h2>Advanced Presentation Editor Syntax</h2>
	<p>
		To separate slides, use "{$SLIDESEP}". Parameters start with a @ symbol.
	</p>

	<h3>Example presentation markup</h3>
	<pre>
@foreground:blue
@background:white
Slide1 text
{$SLIDESEP}  
Slide with default parameters.

This is some filler text.
{$SLIDESEP}
@foreground:white
@background:black
Slide2 text 
@foreground:orange

This slide will have orange text.
  </pre>

	<h3>Available parameters</h3>
	<dl>
		<dt>@foreground</dt>
		<dd>Changes the foreground text color. eg <tt>@foreground:red</tt></dd>

		<dt>@background</dt>
		<dd>Changes the background slide color. eg <tt>@background:blue</tt></dd>

    <dt>@delaySeconds</dt>
    <dd>How long in seconds to delay on this slide before moving to the next one, there is a minimum delay. eg <tt>@delaySeconds:10</tt> to delay for 10 seconds.</dd>

    <dt>@picture</dt>
    <dd>A picture on the local machine to show on the slide. PNG, JPG and GIF should be fine. eg <tt>@picture:C:\Folder Of Media\coolPicture.png</tt>

    <dt>@fontSize</dt>
    <dd>The size of the font to use.</dd>
  </dd>
	</dl>

  <h3>Paramters available in the future</h3>
  <p>
    <tt>@pictureAlign</tt>
  </p>
</div>