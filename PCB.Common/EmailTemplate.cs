namespace Pcb.Common
{
	public static class EmailTemplate
	{

		public const string EmailTop = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n" +
				"<html xmlns=\"http://www.w3.org/1999/xhtml\">\n" +
					"<head>\n" +
						"<title>Pro Vision Cookbook</title>\n" +
						"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n" +
						"<meta name=\"viewport\" content=\"width=device-width\" />\n" +
						"<!--- CSS will be here --->\n" +
						"<style type=\"text/css\" >\n" +
							"@font-face {font-family:Calibri}\n " +
							"p.MsoNormal, li.MsoNormal, div.MsoNormal, body {\n" +
							"margin:0; margin-bottom:.0001pt; font-size:11.0pt; font-family:'Calibri',sans-serif\n}\n" +
							"a:link, span.MsoHyperlink {color:#0563C1; text-decoration:underline} " +
							"a:visited, span.MsoHyperlinkFollowed {color:#954F72; text-decoration:underline} " +
							"@page WordSection1 {margin:72.0pt 72.0pt 72.0pt 72.0pt} " +
							"div.WordSection1 {} ol {margin-bottom:0} ul {margin-bottom:0}" +
							"@media only screen and(max-width:590px)\n" +
							"{\n" +
								".c1{" +
									"background - color:white!important;" +
								"}" +
								".c3a, .c3b{" +
									"width: 100 % !important;" +
								"}\n" +
							"}\n" +
						"</style>\n" +
					"</head>\n" +
					"<body>\n" +
						"<center>\n" +
							"<!-- Email template container-->\n" +
							"<table border=\"0\" cellpadding=\"0\" height=\"100\" width=\"100%\">\n" +
								"<tr>\n" +
									"<td align=\"center\" valign=\"top\" class=\"email-container\">\n" +

									"<!-- Email content -->\n" +
									"<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"580\">\n" +
									"<!--Header-->\n" +
										"<tr>\n" +
											"<td align=\"center\" valign=\"middle\" class=\"header\">\n";

		public const string EmailBottom = "" +
									"<!-- Footer -->\n" +
									"<tr>\n" +
										"<td align=\"center\" valign=\"middle\" class=\"footer\">\n" +
											"<p>Footer text(don't forget about CAN-SPAM and GDPR!)</p>\n" +
										"</td>\n" +
									"</tr>\n" +

								"</table>\n" +
							"</td>\n" +
						"</tr>\n" +
					"</table>\n" +
				"</center>\n" +
			"</body>\n" +
		"</html>\n" +
	"</body>";
	}
}
