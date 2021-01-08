async function LoadView(controller, action, divIdentifier) {

    const clientUrl = `/${controller}/${action}`;

    const page = await fetch(clientUrl);
    const pageHtml = await page.text();

    document.getElementById(divIdentifier).innerHTML = pageHtml;
}