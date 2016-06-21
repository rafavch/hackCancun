<?php
require 'PHPMailer/PHPMailerAutoload.php';

$mail = new PHPMailer;

//$mail->SMTPDebug = 3;                               // Enable verbose debug output

$mail->isSMTP();                                      // Set mailer to use SMTP
$mail->Host = 'smtp.mail.yahoo.com;smtp.mail.yahoo.com';  // Specify main and backup SMTP servers
$mail->SMTPAuth = true;                               // Enable SMTP authentication
$mail->Username = 'rafavch@yahoo.com';                 // SMTP username
$mail->Password = 'POGOyahoo28';                           // SMTP password
$mail->SMTPSecure = 'tls';                            // Enable TLS encryption, `ssl` also accepted
$mail->Port = 25;                                    // TCP port to connect to

$mail->setFrom('rafavch@yahoo.com', 'VR-ehab');
$mail->addAddress('rafavch@gmail.com', 'Doctor');     // Add a recipient
$mail->addAddress('rafavch@gmail.com');               // Name is optional
$mail->addReplyTo('rafavch@gmail.com', 'Information');
$mail->addCC('rafavch@gmail.com');
$mail->addBCC('rafavch@gmail.com');

//$mail->addAttachment('/var/tmp/file.tar.gz');         // Add attachments
//$mail->addAttachment('/tmp/image.jpg', 'new.jpg');    // Optional name
//$mail->isHTML(true);                                  // Set email format to HTML

$mail->Subject = 'Progreso de paciente!!!';
$mail->Body    = 'El niño ...... ha mejorado su nivel en el tratamiento logrando inclinar mucho más el objetivo <b>En hora buena!</b>';
$mail->AltBody = 'This is the body in plain text for non-HTML mail clients';

if(!$mail->send()) {
    echo 'Message could not be sent.';
    echo 'Mailer Error: ' . $mail->ErrorInfo;
} else {
    echo 'Message has been sent';
}