import logging
import datetime
logging.basicConfig(level=logging.INFO, filename=f"{datetime.date.today()}.log",filemode="w",
                    format="%(asctime)s %(levelname)s %(message)s")

logger = logging.getLogger(__name__)