﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Ma première page html</title>
    <link href="styles/ContactUsStyles.css" rel="stylesheet" type="text/css" />
    <style>
        fieldset {
            background-color: lightgreen;
        }
    </style>
</head>
<body>
    <article>
        <header>
            <img src="images/Contoso.png" alt="Company logo"/>
            <h1> Contact Contoso Conferencing</h1>
        </header>
        <section>
            <p>Contoso Conferencing Ltd.</p>
            <p>
                123 South Street<br />
                Somewhere<br />
                Over There<br />
                <em>USA</em>
            </p>
            <p>
                <a href="mailto:contact@contoso.com">contact@contoso.com</a>
            </p>
        </section>
        <section>
            <p>
                If you would like to contact Contoso Conferencing, whether you're interested in our services or in a conference we're currently organizing, don't hesitate to contact us using our enquiry form (<strong>Bold fields</strong> are required).
            </p>
            <form method="post" action="reponse.aspx">
                <fieldset style="background-color:lightblue">
                    <legend>
                        Your Details and Enquiry
                    </legend>
                    <ol>
                        <li>
                            <label id="label1">
                                <strong>Full Name</strong><br />
                                <input type="text" class="inputSimple gras" name="UserName" id="input1" />
                            </label>
                        </li>
                        <li>
                            <label>
                                Telephone number<br />
                                <input type="text" class="inputSimple" name="Phone" id="input2" />
                            </label>
                        </li>
                        <li>
                            <label id="4">
                                Email Address<br />
                                <input type="text" class="inputSimple" name="Email" id="input3" />
                            </label>
                        </li>
                        <li>
                            <label>
                                <strong>Message</strong><br />
                                <textarea name="Message" cols="30" rows="10">add your message here</textarea>
                            </label>
                        </li>
                    </ol>
                </fieldset>
                <input type="submit" value="Send" />
            </form>
        </section>
    </article>
    <footer>
        <p>
            <small>
                Last updated <time datetime="2012-08">August 2012</time>
            </small>
        </p>
    </footer>
</body>
</html>
