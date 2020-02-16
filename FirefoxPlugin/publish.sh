# https://extensionworkshop.com/documentation/develop/web-ext-command-reference/
# Значения для ключей --api-key и --api-secret берутся из переменных окружения $WEB_EXT_API_KEY и $WEB_EXT_API_SECRET.
# Для подписания нужно создать эти переменные и указать значения из https://addons.mozilla.org/en-US/developers/addon/api/key/
~/node_modules/web-ext/bin/web-ext sign --channel unlisted --artifacts-dir ./artifacts --source-dir ./src